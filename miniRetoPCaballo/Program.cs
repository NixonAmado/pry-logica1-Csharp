//traté de practicar con temas como clases, funciones y matricez para aprenderme la sintaxis de C#.

using System.Collections;
using System;
using System.Collections.Generic;



public class TableroManagement{
    string [][] tablero;
    private List<string> movimientos = new List<string>();
     // Definir los códigos de escape ANSI para los colores
    string redColorCode = "\u001b[31m"; // Código de escape ANSI para color rojo
    string blueColorCode = "\u001b[34m"; // Código de escape ANSI para color azul
    string resetColorCode = "\u001b[0m"; // Código de escape ANSI para restablecer el color

    
    public TableroManagement(string [][] tablero){
        this.tablero = tablero;
    }

     public void posicionesY(int y,int x){
        
        int contador=0;
        int direccionY= 2;
        int direccionX= - 1;
        
        while(contador < 2){
            contador++;
            direccionY*= - 1;
            
            for(int par = 1; par < 3; par++){
                try{
                    direccionX*= - 1;
                    movimientos.Add(this.redColorCode + this.tablero[y - direccionY][x - direccionX] + this.resetColorCode);
                    this.tablero[y - direccionY][x - direccionX] = this.redColorCode + " P" + this.resetColorCode;
                    
                }
                catch(Exception){
                    // no existe la posicion
                }
            }
        }
    }
     public void posicionesX(int y,int x){
        
        int contador=0;
        int direccionY= - 1;
        int direccionX= 2;
        
        while(contador < 2){
            contador++;
            direccionX*= - 1;
            
            for(int par = 0; par < 2; par++){
                try{
                    direccionY*= - 1;
                    movimientos.Add(blueColorCode + this.tablero[y - direccionY][x - direccionX] + resetColorCode); 
                    this.tablero[y - direccionY][x - direccionX] = blueColorCode + " P" + resetColorCode;
                }
                catch(Exception){
                    // no existe la posicion
                }
            }
        }
    }
    
    public string verPosiciones{
        get 
        {
            return string.Join(" ", movimientos);
        }
    }
}

public class miniReto

{
    
    private static string[][] CrearTablero(){
        
        string [] letrasTablero = {"a","b","c","d","e","f","g","h"};
       	string [][] tableroAjedrez = new string[8][];
        
    	for (int i = 0; i < letrasTablero.Length; i++){
         	List<string> fila = new List<string>();
  	 
         	foreach (string letra in letrasTablero){
            	fila.Add($"{letra}{i+1}");
         	    
         	}
       	 
        	tableroAjedrez[i] = fila.ToArray();
    	}
   	    return tableroAjedrez;
    }
    
    
    
	private static void Main(string[] args)
	{
        string [][] tablero = CrearTablero();
    
    	Console.WriteLine("-----------posiciones en un tablero de ajedrez-------------");
    	Array.Reverse(tablero);
    	TableroManagement adminTablero = new TableroManagement(tablero);
    	Console.Write("Ingrese la posicion del caballo: ");
    	string? posicion = Console.ReadLine();
   	 
    	foreach(string[] fila in tablero){
    	    int indexPosicion = Array.IndexOf(fila, posicion?.ToLower());
        
        	if(indexPosicion != -1){
            	int indexArray = Array.IndexOf(tablero, fila);
           	    tablero[indexArray][indexPosicion]="\u001b[33m ♘\u001b[0m";
           	    adminTablero.posicionesY(indexArray,indexPosicion);
           	    adminTablero.posicionesX(indexArray,indexPosicion);
        	}
        //	Console.WriteLine("".PadRight(16) + string.Join(" ",fila));
        	
    	}
    	if(adminTablero.verPosiciones.Length!=0){
    	    Console.Clear();
    	    Console.WriteLine($"\n\nPosiciones posibles para el caballo en la posicion {posicion?.ToLower()}: ");
    	    Console.WriteLine("".PadRight(16) + adminTablero.verPosiciones + "\n\n");
    	   
    	    foreach(string[] filaVisual in tablero)
    	    {
                Console.WriteLine("".PadRight(16) + string.Join(" ",filaVisual));
    	    }
    	}else{
    	    Console.WriteLine("No se ha podido encontrar la posicion ingresada");
    	}
    	    
    	}
}









