/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.BL;

import idhand.CodigoQR;
import idhand.DAO.CodigoQRDAO;

/**
 *
 * @author Usuario
 */
public class CodigoQRBL extends CodigoQRDAO {
    
    @Override
    public boolean generarCodigoQR(){
        return true;
    }
    
    @Override
    public boolean verCodigoQR(CodigoQR qr){
        return true;
    }
    
    /**
     *
     * @param qr
     * @return
     */
    @Override
    public boolean eliminar(CodigoQR qr){
        return true;
    }
    
    @Override
    public boolean descargar(CodigoQR qr){
        return true;
    }
    
    @Override
    public boolean leerCodigoQR(){
        return true;
    }

}
