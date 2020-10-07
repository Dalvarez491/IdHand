<?php
            $con=mysqli_connect("localhost","root","","idhand");
            // Verificar conexion
            if (mysqli_connect_errno())
              {
              echo "Falló la conexión con la base de datos: " . mysqli_connect_error();
              }

            $sql="INSERT INTO tbl_administrador (Nombre_A,Correo_A,Contraseña_A) VALUES ('".$_POST['nombre']."','".$_POST['correo']."','".$_POST['clave']."')";

            if (!mysqli_query($con,$sql)){
              die('Error: ' . mysqli_error($con));
             }
            echo "¡Exitosamente guardado!";


             
            mysqli_close($con);
      
     ?>