function validar() {
    var correo = document.getElementById("correo").value;
    var clave = document.getElementById("clave").value;

    let regexCorreo = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;   //Expresión regular para el correo

    if(correo == 0 || clave == 0){
        alert("Todos los campos son obligatorios.");
        return false;
    }

    else if (clave.length < 5){
            alert("La contraseña es muy corta, intenta con otra.");
            return false;
    }

    else if (!regexCorreo.test(correo)){
        alert("El correo electrónico no es válido");
        return false;
    }
}