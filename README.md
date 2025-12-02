<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# De compras con principios de POO

## Contexto

Este proyecto es parte de un sitio de comercio electrónico. Te damos algunas
clases ya implementadas y deberás agregar otras.

La clase [`Product`](./src/Library/Product.cs) que te damos representa un
producto a la venta en el sitio y tiene las responsabilidades de conocer el
nombre `Name`, la categoría `Category` y el precio `Price` del producto. La
categoría es el tipo de producto, por ejemplo, `Electrónica`, `Bazar`, etc.

La clase [`ShoppingCart`](./src/Library/ShoppingCart.cs) tiene la
responsabilidad de conocer los ítems agregados al carrito, de agregar productos
`void AddToCart(Product)` al carrito, de remover productos del carrito `void
RemoveFromCart(Product)`, y de calcular el total de los ítems en el carrito
`double GetTotal()`.

Internamente, la clase `ShoppingCart` usa otra clase `CartItem` para representar
los ítems agregados al carrito; esa clase tiene la responsabilidad de conocer un
producto `Product` y la cantidad de ese producto `Quantity`. De esta forma, el
método `void AddToCart(Product)` agrega un nuevo ítem si ese producto no estaba,
o suma uno a la cantidad de ese producto. De forma análoga, el método `void
RemoveFromCart(Product)` disminuye en uno la cantidad de un producto, o remueve
el ítem si había uno solo.

Las clases anteriores funcionan correctamente, hay casos de prueba para
mostrarlo.

## Descuentos

Una novedad en el sitio de comercio electrónico es que, a partir de ahora, puede
haber cupones de descuento. Por el momento hay algunos cupones ya definidos,
pero podrán haber otros en el futuro.

Algunos de los descuentos que hay hoy en día son:

* Cupón 2x1: por cada dos productos iguales, sólo se cobra uno de ellos.

* Cupón de descuento: se descuenta cierto porcentaje del total del carrito; este
  cupón no es acumulable con otros cupones.

* Cupón de categoría en oferta: se descuenta cierto porcentaje de los productos
  de cierta categoría; este cupón es acumulable con otros cupones.

## Consigna

Modifica lo que consideres necesario para implementar estos cupones. Recuerda
que podrá haber otros cupones en el futuro. Haz las modificaciones teniendo en
cuenta las guías de diseño vistas en el curso.
