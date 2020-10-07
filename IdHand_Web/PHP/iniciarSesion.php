<?php

$dbhost="localhost";
$dbuser="root";
$dbpass="";
$dbname="idhand";

$con = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname);
if (!$con){
    die("No hay conexion: ".mysqli_connect_error());
}

$Correo= $_POST["correo"];
$Contraseña = $_POST["clave"];

$query = mysqli_query($con, "SELECT * FROM `tbl_administrador` WHERE Correo_A = '".$Correo."' and Contraseña_A = '".$Contraseña."'");
$nr = mysqli_num_rows($query);

if ($nr == 1){

    echo "Bienvenido";
}

else if ($nr == 0){
    echo "No ingreso";
}

?>