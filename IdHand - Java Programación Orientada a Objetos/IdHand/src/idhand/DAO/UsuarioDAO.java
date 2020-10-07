/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.DAO;

import idhand.Usuario;

/**
 *
 * @author Usuario
 */
public class UsuarioDAO extends PersonaDAO{

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
    
    public boolean registrarse(Usuario us){
        return true;
    }
    
    public boolean igresarInformacion(Usuario us){

        return true;
    }
    
    public boolean modificarInformacion(Usuario us){
        return true;
    }
    
    public boolean eliminarInformacion(Usuario us){
        return true;
    }
    
    public boolean solicitarPadecimiento(Usuario us){
        return true;
    }
    
}
