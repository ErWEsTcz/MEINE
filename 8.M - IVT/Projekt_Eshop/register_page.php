<!DOCTYPE html>
<html>
    <head>
        <title>Sign Up Form</title>
        <link rel="stylesheet" href="styles_js.css"> <!-- Zde propojíme s CSS souborem. -->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css ">
    </head>
    <body>
        <button id="darkmodebtn" onclick="darkMode()"><i class="bi bi-moon-fill"></i></button>
        <form id="form" action="login.php" method="post">   
            <!-- action: kam se půjde po sumbit -->
            <!-- method: jakou metodou se budou posílat data (GET x POST) -->         
            <h1>Sign Up</h1>
            <p>Please fill in this form to sign up.</p>
            <hr>

            <label for="firstName"><b>First Name</b></label>
            <input type="text" placeholder="Enter your first name" name="firstName" required>

            <label for="lastName"><b>Last Name</b></label>
            <input type="text" placeholder="Enter your last name" name="lastName" required>
            
            <label for="email"><b>Email</b></label>
            <input type="email" placeholder="Enter Email" name="email" required>
            <!-- atribut 'name' se použije v metodě POST -->

            <label for="pwd"><b>Password</b></label>
            <input type="password" id="pwd" placeholder="Enter Password" name="pwd" required>

            <label for="newsletter"><b>Newsletter</b></label><br>
            <input type="checkbox" id="newsletter" required>

            <div class="button-container">
                <button type="submit" class="signupbtn">Log In</button>
                <!-- Nutné zde dát type="sumbit" jako signál pro vyhodnocení formuláře (pomocí action a method)-->
            </div>
        </form>
        <script src="myScript.js"></script>
    </body>
</html>