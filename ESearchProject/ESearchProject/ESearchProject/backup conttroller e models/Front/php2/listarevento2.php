<!DOCTYPE <!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Page Title</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" media="screen" href="main.css" />
    <script src="main.js"></script>
</head>
<body>
    <?php
    include_once "conexao.php";
    $result_usuario =	"SELECT * from markers ORDER BY id DESC";
    $resultado_usuario = mysqli_query ($conn,$result_usuario);
        
    //verificar
    if(($resultado_usuario) AND ($resultado_usuario->num_rows != 0)){
        while($row_usuario = mysqli_fetch_assoc($resultado_usuario)){
        
            echo $row_usuario['address'];

            $address = '575, Avenida Paulista, Sao Paulo';
            
            
            echo '<iframe width="500" height="250" frameborder="0" scrolling="yes" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?f=q&source=s_q&hl=en&geocode=&q=' . str_replace(",", "", str_replace(" ", "+", $address)) . '&z=14&output=embed" ></iframe>';
        }
    }else {
        echo "Nenhum resultado encontrado";
        
        
    }
    ?>
    
                <!-- TESTE -->

                










</body>
</html>



