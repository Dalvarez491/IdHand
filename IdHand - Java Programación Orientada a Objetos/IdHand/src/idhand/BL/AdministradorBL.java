/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.BL;

import idhand.Administrador;
import idhand.Usuario;

/**
 *
 * @author Usuario
 */
public class AdministradorBL extends PersonaBL{ 

    @Override
    public boolean cerrarSesion() {
        return super.cerrarSesion(); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean recuperarContraseña() {
        return super.recuperarContraseña(); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean iniciarSesion() {
        return super.iniciarSesion(); //To change body of generated methods, choose Tools | Templates.
    }
    
    public boolean crearAdministrador(Administrador Admi){
        //Logica
        return true;
    }
    
    public boolean crearUsuario (Administrador Admi){
        //Logica
        return true;
    }
    
    public boolean consultarUusario(Administrador Admi){
        //Logica
        return true;
    }
    
    public boolean actualizarUsuario (Administrador Admi){
        //Logica
        return true;
    }
    
    public boolean eliminarUsuario(Usuario us){
        //Logica
        return true;
    }
    
    public boolean eliminarAdministrador (Administrador Admi){
        //Logica
        return true;
    }
    
}
