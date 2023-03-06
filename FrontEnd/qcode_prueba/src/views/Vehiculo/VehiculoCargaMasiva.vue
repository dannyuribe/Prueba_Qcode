<template>
  <div >
    <h1>Vehiculo Carga Masiva</h1>
    <div class="row">
        <label class="form-label" for="formFile">Cargar Archivo:</label>
        <input 
            class="form-control" 
            type="file" 
            id="formFile" 
            ref="archivo" 
            accept=".xlsx"
            @change="CargarArchivo">
        <button class="btn btn-primary" @click="GuardarVehiculo">Cargar</button>
    </div>
  </div>
</template>

<script>
import utilidades from "@/services/Axios";
export default {
    name:'VehiculoCargaMasiva',
    data() {
        return {
            archivo: null,
        }
    },
    methods: {
        CargarArchivo(event) {
            this.archivo = event.target.files[0];

            if (!this.archivo) {
                console.error("No se ha seleccionado ningún archivo");
                return;
            }

            const lectorArchivo = new FileReader();
            lectorArchivo.readAsDataURL(this.archivo);
        },
        GuardarVehiculo() {
            console.log("d");
            if (!this.archivo) {
                console.log("no hay archivo seleccionado.");
                return;
            }
            const formData = new FormData();
            formData.append('archivo', this.archivo);

            utilidades.PostArchivo("Vehiculos/cargar-excel-vehiculos" ,formData)
                .then((respuesta) => {
                    console.log("respuesta: " + respuesta);
                }).catch((error) => {
                    console.log("error:" + error);
                });            
        }
    },
}
</script>

<style>

</style>