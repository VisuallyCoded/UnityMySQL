<?php

$con = mysqli_connect('localhost:3306', 'root', 'root', 'visual');
//check connection

if (mysqli_connect_errno()) {
	echo "E"; //error code #1 = connection failed
	exit();
}

$username = $_POST["name"];
$newscore = $_POST["score"];


// namecheck
$namecheckquery = "SELECT username, score FROM players WHERE username = '" . $username . "';";
$namecheck = mysqli_query($con, $namecheckquery) or die("E"); //error code #2 - name check query failed
if (mysqli_num_rows($namecheck) != 1) {
	echo ("E"); //error code #3 - name exists cannot register
	exit();
}


$updatequery = "UPDATE players SET score = " . $newscore . " WHERE username = '" . $username . "';";
//get login info from query
$existinginfo = mysqli_fetch_assoc($namecheck);
mysqli_query($con, $updatequery) or die ("E"); //error code #7 save failed

echo "0";


?>