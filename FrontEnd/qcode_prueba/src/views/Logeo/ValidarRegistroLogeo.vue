<template>
    <div>
        <h1>Validar Registro Usuario</h1>
        <div class="btn-toolbar justify-content-left contenedorBoton">
            <router-link 
                class="btn btn-primary" 
                :to="{ name: 'LogeoPrincipal' }">
                    Regresar
            </router-link>
        </div>
        <form action="" class="FormularioCodigoVerificacion">
            <div>
                <label class="form-label" for="EntradaCorreo">Correo</label>
                <input class="form-control" type="text" id="EntradaCorreo">
            </div>
            <div>
                <label class="form-label" for="EntradaCodgioVerificacion">C&oacute;digo verificaci&oacute;n</label>
                <input class="form-control" type="text" id="EntradaCodgioVerificacion">
            </div>
        </form>
        <div class="contenedorBoton">
            <button class="btn btn-primary"> Validar</button>
        </div>        
    </div>
</template>

<script>
export default {
    name: "ValidaRegistroLogeo",
}
</script>

<style>
.FormularioCodigoVerificacion{
    margin: auto;
    width: 50%;
    padding: 10px;    
    border-radius: 10px;
    border: 2px solid white;
}
</style>