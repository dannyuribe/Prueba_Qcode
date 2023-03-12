<template>
    <div>
        <h1>Validar Registro Logeo</h1>
        <form action="" class="FormularioCodigoVerificacion">
            <div>
                <label class="form-label" for="EntradaCorreo">Correo</label>
                <input class="form-control" type="text" id="EntradaCorreo">
            </div>
            <div>
                <label class="form-label" for="EntradaCodgioVerificacion">C&oacute;digo de verificaci&oacute;n</label>
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
}
</style>