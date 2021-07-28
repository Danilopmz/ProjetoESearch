<?php

function get_endereco($cep){
    //formatar o cep removendo caracteres nao numericos
    $cep = preg_replace("/[^0-9]/","",$cep);
    $url = "http://viacep.com.br/ws/$cep/xml/";

    $xml = simplexml_load_file($url);
    return $xml
}

var_dump(get_endereco("07179240"));



?>