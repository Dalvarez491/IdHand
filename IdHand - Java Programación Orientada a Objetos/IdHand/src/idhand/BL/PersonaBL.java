/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.BL;

import idhand.DAO.PersonaDAO;

/**
 *
 * @author Usuario
 */
public class PersonaBL extends PersonaDAO{

    
    @Override
    public boolean iniciarSesion(){
        return true;
    }
    
    @Override
    public boolean recuperarContraseña(){
        return true;
    }
    
    @Override
    public boolean cerrarSesion(){
        return true;
    }

}
