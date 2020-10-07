/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand.BL;

import idhand.Audio;
import idhand.DAO.AudioDAO;

/**
 *
 * @author Usuario
 */
public class AudioBL extends AudioDAO{
    
    @Override
    public boolean grabarAudio(){
        return true;
    }
    
    @Override
    public boolean verAudio(Audio audi){
        return true;
    }
    
    /**
     *
     * @param audi
     * @return
     */
    @Override
    public boolean eliminarAudio(Audio audi){
        return true;
    }
    
    @Override
    public boolean descargarAudio(Audio audi){
        return true;
    }
    
}
