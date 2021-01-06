<?php

$con = mysqli_connect('localhost:3306', 'root', 'root', 'video');
//check connection

if (mysqli_connect_errno()) {
	echo "1. Connection failed"; //error code #1 = connection failed
	exit();
}

$username = $_POST["videoselection"];



// namecheck
$videourl = "SELECT url FROM players WHERE username = '" . $username . "';";



$namecheck = mysqli_query($con, $namecheckquery) or die("2. Name check query failed"); //error code #2 - name check query failed
if (mysqli_num_rows($namecheck) != 1) {
	echo ("5. User does not exist, or more than one in database"); //error code #3 - name exists cannot register
	exit();
}


$updatequery = "UPDATE players SET score = " . $newscore . " WHERE username = '" . $username . "';";
//get login info from query
$existinginfo = mysqli_fetch_assoc($namecheck);
mysqli_query($con, $updatequery) or die ("7: Save query failed"); //error code #7 save failed

echo "0";


?>