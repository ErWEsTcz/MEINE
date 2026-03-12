<?php

/* sem doplňte kód po vzoru login.php */

/* pomocný kód */
if($_POST["remember"]=="on"){
    $newsletter = "TRUE";
}
else{
    $newsletter = "FALSE";
}

// uložíme uživatele s těmito údaji do databáze
$sql = "INSERT INTO Users (FirstName, LastName, Email, Newsletter, Password) VALUES ('$first_name', '$last_name', '$email',$newsletter, '$password')"; 


/* sem doplňte kód po vzoru login.php */

?>