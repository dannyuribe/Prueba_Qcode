<template>
    <form class="formularioContenedor" @submit.prevent="enviarDatos">
        <div class="row row-cols-2 formularioUsuario">
            <div class="col">
                <label for="entradaNombre" class="form-label">Nombre</label>
                <input 
                    class="form-control" 
                    type="text" 
                    id="entradaNombre"
                    v-model="Usuario.Nombre">
            </div>
            <div class="col">
                <label for="entradaApellido" class="form-label">Apellido</label>
                <input 
                    class="form-control" 
                    type="text" 
                    id="entradaApellido"
                    v-model="Usuario.Apellido">
            </div>
            <div class="col">
                <label for="entradaTelefono" class="form-label">Tel&eacute;fono</label>
                <input 
                    class="form-control" 
                    type="text" 
                    id="entradaTelefono"
                    v-model="Usuario.Telefono">
            </div>
            <div class="col">
                <label for="entradaCorreo" class="form-label">Correo</label>
                <input 
                    class="form-control" 
                    type="text" 
                    id="entradaCorreo"
                    v-model="Usuario.Correo">
            </div>            
        </div>
        <div>
                <label for="entradaContrasena" class="form-label">Contraseña</label>
                <input 
                    class="form-control" 
                    type="password" 
                    id="entradaContrasena"
                    v-model="Usuario.Contrasena">
        </div>
    </form>
</template>

<script>
export default {
    name: "formularioUsuario",
    data() {
        return {
            Usuario:{
                Nombre:null,
                Apellido: null,
                Telefono: null,
                Correo: null,
                Contrasena: null
            }
        }
    },
    created() {
        this.enviarDatos();
    },
    methods: {
        enviarDatos(){
            this.$emit('usuario-enviado', this.Usuario);
        }
    },
}
</script>

<style>
.formularioContenedor{
    padding: 10px;    
    border-radius: 10px;
    border: 2px solid white;
}
.formularioUsuario{
    margin: auto;
    padding: 10px;
}
</style>