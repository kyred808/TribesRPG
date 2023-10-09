$repackver = 14;

//Plasmatic echo
function pecho(%m)
{
	//$console::printlevel = 1;
	echo(String::getSubStr(%m, 0, 250));
	//$console::printlevel = 0;		
}

function remoteRSound(%server, %val)
{//By phantom - beatme101.com, tribesrpg.org
	//This function is useful for disabling or resetting sound.
	//It can be useful for any server to induce silence.

	//Send a value of 1 to turn off sound.
	//Send a value of 2 to turn sound back on.
	//Send a value of 3 to turn sound off, then back on (to end currently playing sounds such as music).

	if(%server != 2048)
		return;

	if(%val & 1)
	{
		sfxclose();
	}

	if(%val & 2)
	{
		sfxopen();
	}
}

function sendControl(%val, %mod)
{//By phantom - beatme101.com, tribesrpg.org
	remoteEval(2048,RawKey,%val, %mod);
}
function remoteRepackIdent(%server, %val)
{
	if(%val && %server == 2048)
		remoteeval(%server, RepackConfirm, 14);
}
function remoteRepackKeyOverride(%server, %val)
{//By phantom - beatme101.com, tribesrpg.org
	if(%server == 2048){
		if(%val)
			$repackKeyOverride = True;
		else
			$repackKeyOverride = "";
	}
}

function String::len(%string)
{
	%chunk = 10;
	%length = 0;

	for(%i = 0; String::getSubStr(%string, %i, 1) != ""; %i += %chunk)
		%length += %chunk;
	%length -= %chunk;

	%checkstr = String::getSubStr(%string, %length, 99999);
	for(%k = 0; String::getSubStr(%checkstr, %k, 1) != ""; %k++)
		%length++;

	if(%length == -%chunk)
		%length = 0;

	return %length;
}

//=====================================================
//Buffered Center Print
//Written by Bovidi
//This function is designed for low speed input, to
//generate long messages all at once.
//Message is sent 255 chars at a time, and displays only
//when the last message has been recieved.
//Despite the name, this function can print to any
//location on the screen (top, bottom, center).
//======================================================
function remoteBufferedCenterPrint(%server, %string, %timeout, %location) {

	if(%server != 2048) {
		return false;
	}

	if(%timeout > 0) {
		//Begin the string
		$RPG::bufferedTextOverflow = false;
		$RPG::bufferedTextLength = 0;
		$RPG::bufferedText = "";
		$RPG::bufferedTextTimeout = %timeout;
	}

	if($RPG::bufferedTextOverflow)
		return;

	$RPG::bufferedText = $RPG::bufferedText @ %string;
	$RPG::bufferedTextLength = $RPG::bufferedTextLength + String::Len(%string);

	if(%timeout == -1 || $RPG::bufferedTextLength > 1500) {
		//Final piece of text
		$centerPrintId++;
		Client::centerPrint($RPG::bufferedText, %location);
		if($RPG::bufferedTextTimeout)
			schedule("clearCenterPrint(" @ $centerPrintId @ ");", $RPG::bufferedTextTimeout);

		if($RPG::bufferedTextLength > 1500) {
			//Overflow detected
			$RPG::bufferedTextOverflow = true;
		}
	}
}

//=====================================================
//Buffered Console Print
//Written by phantom - tribesrpg.org, beatme101.com
//This function is designed for high frequency messages,
//such as damage messages in battles.
//It can handle 255 chars per input string, and has a
//high number of supported lines.
//Messages are sent and handled similarly to the Tribes
//chat hud, except you should end each line here with \n.
//Changing the value of %max will only have an effect
//on subsequent messages.
//======================================================
function remoteBufferedConsolePrint(%server, %string, %timeout, %location, %max) {
	if(%server != 2048){
		return;
	}
	%max = floor(%max);
	$ConsolePrintText[$cprintnum++] = %string;
	for(%i = 1; $ConsolePrintText[%i] != ""; %i++)
			%msg = %msg @ $ConsolePrintText[%i];
	$centerPrintId++;
	Client::centerPrint(%msg, %location);
	schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);

	if(String::len(%msg) > 1500){//overflowing
		for(%i = 1; $ConsolePrintText[%i] != ""; %i++)
			$ConsolePrintText[%i-1] = $ConsolePrintText[%i];
		$cprintnum--;
		$ConsolePrintText[%i] = "";
		$ConsolePrintText[0] = "";
	}
	//for(%n=1;$cprintnum >= %max;%n++){
	if($cprintnum >= %max){
		for(%i = 1; $ConsolePrintText[%i] != ""; %i++){
			if(%i <= %max)
				$ConsolePrintText[%i-1] = $ConsolePrintText[%i];
			else
				$ConsolePrintText[%i] = "";
		}
		$cprintnum = %max-1;
		$ConsolePrintText[0] = "";
	}
}

function remoteClearBufferedConsole(%server){
//Written by phantom - tribesrpg.org, beatme101.com
	if(%server != 2048){
		return;
	}
	for(%i = 1; $ConsolePrintText[%i] != ""; %i++)
		$ConsolePrintText[%i] = "";
	$cprintnum = "";
}


function use(%desc)
{
	%type = getItemType(%desc);
	if (%type != -1) {
		if($repackKeyOverride)
			remoteEval(2048,useItem,%type);//Delivers clientID. Works even in observer. May be delivered out of order.
		else
			useItem(%type);//Delivers playerID. Will make sure the use is sequenced correctly with trigger events.
	}
	else {
		pecho("Unknown item \"" @ %desc @ "\"");
	}
}