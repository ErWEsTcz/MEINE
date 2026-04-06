<?php 
include "db.php";

$FirstName = $_POST["firstName"];
$LastName = $_POST["lastName"];
$Email = $_POST["email"];
$Password = $_POST["pwd"];

if($_POST["newsletter"] == "on"){
    $Newsletter = "TRUE";
}
else{
    $Newsletter = "FALSE";
}

$sql = "INSERT INTO users (FirstName, LastName, Email, Newsletter, Password)
        SELECT '$FirstName', '$LastName', '$Email', $Newsletter, '$Password'
        WHERE NOT EXISTS (SELECT 1 FROM users WHERE Email = '$Email')";

$result = $conn->query($sql);
Header("Location:login_page.php");
?>
