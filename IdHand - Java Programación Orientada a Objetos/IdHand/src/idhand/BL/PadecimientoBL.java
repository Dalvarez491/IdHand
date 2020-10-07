/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.BL;

import idhand.DAO.PadecimientoDAO;
import idhand.Padecimiento;

/**
 *
 * @author Usuario
 */
public class PadecimientoBL extends PadecimientoDAO {
    
    @Override
    public boolean crear(){
        return true;
    }
    
    @Override
    public boolean leer(Padecimiento pa){
        return true;
    }
    
    @Override
    public boolean actualizar(Padecimiento pa){
        return true;
    }
    
    @Override
    public boolean eliminar(Padecimiento pa){
        return true;
    }
    
}
