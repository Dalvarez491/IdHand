/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.BL;

import idhand.Contacto;
import idhand.DAO.ContactoDAO;

/**
 *
 * @author Usuario
 */
public class ContactoBL extends ContactoDAO{
    
    @Override
    public boolean crear(Contacto co){
        return true;
    }
    
    @Override
    public boolean leer(Contacto co){
        return true;
    }
    
    @Override
    public boolean actualizar(Contacto co){
        return true;
    }
    
    @Override
    public boolean eliminar(Contacto co){
        return true;
    }
    
}
