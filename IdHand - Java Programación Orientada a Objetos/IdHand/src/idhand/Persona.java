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
public class Persona {
    
    private int id;
    private String correo;
    private String nombre;
    private String contraseña;
    
    public Persona(){
        
    }

    public Persona(int id, String correo, String nombre, String contraseña) {
        this.id = id;
        this.correo = correo;
        this.nombre = nombre;
        this.contraseña = contraseña;
    }

    public String getContraseña() {
        return contraseña;
    }

    public void setContraseña(String contraseña) {
        this.contraseña = contraseña;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    
}
    
