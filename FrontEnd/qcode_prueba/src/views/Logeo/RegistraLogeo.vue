<template>
    <div>
        <h1>
            Registrar Usuario
        </h1>
        <div class="btn-toolbar justify-content-left contenedorBoton">
            <router-link 
                class="btn btn-primary" 
                :to="{ name: 'LogeoPrincipal' }">
                    Regresar
            </router-link>
        </div>
        <formularioUsuario 
            class="formulario" 
            @usuario-enviado="RecibirDatosUsuario"></formularioUsuario>
        <div class="contenedorBoton">
            <button 
                class="btn btn-primary" 
                @click="RegistrarUsuarioLogeo">
                    Registrar
            </button>
        </div>
    </div>
</template>

<script>
import formularioUsuario from '@/components/FormularioUsuario.Component.vue';

export default {
    name: "RegistraLogeo",
    components: {
        formularioUsuario,
    },
    data() {
        return {
            Usuario:{}
        }
    },
    methods: {
        RecibirDatosUsuario(datos){
            this.Usuario= datos;
        },
        RegistrarUsuarioLogeo(){
            console.log("Usuario: "+this.Usuario.Correo);
        }
    },
}
</script>

<style>
.formulario {
    padding: 10px;
    text-align: center;
    margin: auto;
    width: 70%;
}
</style>