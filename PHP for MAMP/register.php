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

$password = $_POST["password"];
$countrynum = $_POST["country"];

$namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";

$namecheck = mysqli_query($con, $namecheckquery) or die("E\t2"); //error code #2 - name check query failed

mysqli_num_rows($namecheck) < 1 or die("E\t3"); //error code #3 - name exists cannot register

//add user to the table
$salt = "\$5\$rounds=1000\$" . "phantomserverx" . $username . "\$";
$hash = crypt($password, $salt);
$score = 1;

if ($countrynum == 0){ $country = "USA"; }
else if ($countrynum == 1){ $country = "India"; }
else if ($countrynum == 2){ $country = "China"; }
else if ($countrynum == 3){ $country = "Japan"; }
else if ($countrynum == 4){ $country = "Russia"; }

$insertuserquery = "INSERT INTO players (username, hash, salt, score, country) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "', '" . $score . "', '" . $country . "');";

mysqli_query($con, $insertuserquery) or die("E\t4"); //error code $4 - insert query failed

echo "0";
?>