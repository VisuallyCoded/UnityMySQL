<?php

$con = mysqli_connect('localhost:3306', 'root', 'root', 'visual');
//check connection

if (mysqli_connect_errno()) {
	echo "E\t1"; //error code #1 = connection failed
	exit();
}

$username = mysqli_real_escape_string($con, $_POST["name"]);
$usernameclean = filter_var($username, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH );

$username = $usernameclean or die("E\t7"); //error code #7 - usernames cannot contain those characters

$username = $_POST["name"];
$password = $_POST["password"];

$namecheckquery = "SELECT username, salt, hash, score FROM players WHERE username='" . $username . "';";
$namecheck = mysqli_query($con, $namecheckquery) or die("E\t2"); //error code #2 - name check query failed

if (mysqli_num_rows($namecheck) != 1) {
	echo ("E\t3"); //error code #3 - name exists cannot register
	exit();
}

//get login info from query
$existinginfo = mysqli_fetch_assoc($namecheck);

//isolate salt and hash
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

//generate the login hash from the login attempt then compare it with the one in the database
$loginhash = crypt($password, $salt);

//if the loginhash is the same as the encrypted one's we're good

$hash = $loginhash or die("E\t6"); //error code #6 password does not hash to match table

//if we make it to the end we respond with the score.
echo "0\t" . $existinginfo["score"];

?>