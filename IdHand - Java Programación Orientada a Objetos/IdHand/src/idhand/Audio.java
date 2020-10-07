/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand;

/**
 *
 * @author Usuario
 */
public class Audio {
    
    private int idAudio;
    private String audio;
    
   public Audio(){
       
   }

    public Audio(int idAudio, String audio) {
        this.idAudio = idAudio;
        this.audio = audio;
    }

    public String getAudio() {
        return audio;
    }

    public void setAudio(String audio) {
        this.audio = audio;
    }

    public int getIdAudio() {
        return idAudio;
    }

    public void setIdAudio(int idAudio) {
        this.idAudio = idAudio;
    }

}
