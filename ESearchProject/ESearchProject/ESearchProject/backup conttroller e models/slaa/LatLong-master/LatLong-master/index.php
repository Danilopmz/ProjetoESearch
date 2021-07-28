<!DOCTYPE html>
<html>
    <head>
        <title>lat/long</title>
        <script src="https://maps.googleapis.com/maps/api/js?v=3.exp"></script>
        <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    </head>

    <body onload="initialize()">
        <div id="map-canvas" style="width:800px; height:500px;"></div>
        <?php

            $array = Array(
                // "R. Aurora, 611 - Santa Ifigênia, São Paulo - SP, 01209-001",
                // "R. dos Timbiras, 521 - Santa Ifigênia, São Paulo - SP",
                // "R. Vitória, 678 - Jardim Ataliba Leonel, São Paulo - SP, 02324-250",
                // "R. Joaquim Gustavo, 531 - República, São Paulo - SP, 01045-020",
                // "R. Conselheiro Nébias, 236 - Campos Elíseos, São Paulo - SP"
                "R. Sebastião Vieira, 81 - Jardim Ponte Alta, Guarulhos - SP, 07179240"
            );
        ?>
    </body>

</html>
<script>var address = new Array(<?php echo "'".implode("','", $array)."'"?>);</script> 
<script src="map.js"></script>
<script>setTimeout(function(){codeAddress()},1000);</script>