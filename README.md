# Practica 2 - Interfaces Inteligentes
## Introducción a los scripts en Unity


*1.a) Ninguno de los objetos será físico.
![img/1.a.gif](img/1.a.gif)

*1.b) La esfera tiene físicas, el cubo no.
![img/1.b.gif](img/1.b.gif)

*1.c) La esfera y el cubo tienen físicas.
![img/1.c.gif](img/1.c.gif)

*1.d) La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo
![img/1.d.gif](img/1.d.gif)
Los objetos caen a la misma velocidad (esperable en un entorno sin resistencia a la caida, por ej: el vacio)

*1.e) La esfera tiene físicas y el cubo es de tipo IsTrigger
![img/1.e.gif](img/1.e.gif)
 Al setear "IsTrigger" al Collider, ahora las colisiones no se manejan por defecto, si no que deberá ser el programador el que, mediante los eventos:
 * OnTriggerEnter()
 * OnTriggerStay()
 * OnTriggerExit()
Manejará las colisiones

*1.f)La esfera tiene físicas, el cubo es de tipo IsTrigger y tiene físicas.
![img/1.f.gif](img/1.f.gif)

*1.e)La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo,
se impide la rotación del cubo sobre el plano XZ.
Antes
![img/1.g1.gif](img/1.g1.gif)
Despues
![img/1.g1.gif](img/1.g2.gif)
