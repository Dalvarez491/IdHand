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
public class CodigoQR {
    
    private int idQR;
    private String qr;
    
    public CodigoQR(){
        
    }

    public CodigoQR(int idQR, String qr) {
        this.idQR = idQR;
        this.qr = qr;
    }

    public String getQr() {
        return qr;
    }

    public void setQr(String qr) {
        this.qr = qr;
    }

    public int getIdQR() {
        return idQR;
    }

    public void setIdQR(int idQR) {
        this.idQR = idQR;
    }
    
    
    
}
