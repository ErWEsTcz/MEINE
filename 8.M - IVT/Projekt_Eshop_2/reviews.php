<?php session_start();
include "db.php";
include "header.html";
?>

<form id="form">   
            <!-- action: kam se půjde po sumbit -->
            <!-- method: jakou metodou se budou posílat data ("GET" - veřejně v URL x "POST" - skrytě v HTTP requestu ) -->         
            <h1>Log In</h1>
            <p>Please fill in this form to log in.</p>
            <hr>

            <label for="email"><b>Email</b></label>
            <input type="email" placeholder="Enter Email" name="email" required>
            <!-- atribut 'name' se použije v metodě POST -->

            <label for="pwd"><b>Password</b></label>
            <input type="password" id="pwd" placeholder="Enter Password" name="pwd" required>

            <div class="button-container">
                <button type="submit" class="signupbtn">Log In</button>
                <!-- Nutné zde dát type="sumbit" jako signál pro vyhodnocení formuláře (pomocí action a method)-->
            </div>
        </form>


<?php
        $sql = "SELECT * FROM reviews LEFT JOIN users ON reviews.UserID = users.UserID";
        $result = $conn->query($sql);

        while ($review = $result->fetch_assoc()){
            ?>
            <div class="review">
                <h3 class="review-author"><?php echo $review["FirstName"] ." ". $review["LastName"] ?></h3>
                <p class="review-text"><?php echo $review["TextOfReview"]?></p>

                <?php 
                switch ($review["Stars"]){
                    case 1:
                        echo '<p class="stars"> ★ ☆ ☆ ☆ ☆ </p>';
                        break;
                    case 2:
                        echo '<p class="stars"> ★ ★ ☆ ☆ ☆ </p>';
                        break;
                    case 3:
                        echo '<p class="stars"> ★ ★ ★ ☆ ☆ </p>';
                        break;
                    case 4:
                        echo '<p class="stars"> ★ ★ ★ ★ ☆ </p>';
                        break;
                    case 5:
                        echo '<p class="stars"> ★ ★ ★ ★ ★ </p>';
                        break;
                }
                ?>
            </div>
<?php
        }   
?>

</body>
</html>