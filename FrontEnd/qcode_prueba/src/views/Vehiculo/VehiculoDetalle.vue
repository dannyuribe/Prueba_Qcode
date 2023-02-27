<template>
    <div class="cont">
        <h1>Vehiculo</h1>
        <div class="btn-toolbar justify-content-left">
            <router-link class="btn btn-primary" :to="{ name: 'VehiculoPrincipal' }">
                Regresar
            </router-link>
        </div>
        <div class="row row-cols-2">
            <div class="cols">
                <div class="row g-3">
                    <div class="col-12">
                        <label class="form-label" for="serialVehiculoIn">Serial Vehiculo</label>
                        <input v-if="editar" class="form-control" type="text" id="serialVehiculoIn"
                            v-model="vehiculo.serialVehiculo" disabled>
                        <input v-else class="form-control" type="text" id="serialVehiculoIn"
                            v-model="vehiculo.serialVehiculo">
                    </div>

                    <div class="col-6">
                        <label class="form-label" for="placaIn">Placa</label>
                        <input class="form-control" type="text" id="placaIn" v-model="vehiculo.placa">
                    </div>

                    <div class="col-6">
                        <label class="form-label" for="modeloVehiculoIn">Modelo</label>
                        <input class="form-control" type="number" id="modeloVehiculoIn" v-model="vehiculo.modelo">
                    </div>
                    <div class="col">
                        <label class="form-label" for="">Marca</label>
                        <input class="form-control" type="text" id="SerialVehiculoIn" v-model="vehiculo.marca">
                    </div>
                    <div class="col">
                        <label class="form-label" for="costoIngresoIn">Costo Ingreso</label>
                        <input class="form-control" type="text" id="costoIngresoIn" v-model="vehiculo.costo" disabled>
                    </div>
                    <div class="col-12">
                        <label for="formFile" class="form-label">Imagen</label>
                        <input class="form-control" type="file" id="formFile" accept=".jpg, .jpeg" @change="CargarImagen">
                    </div>
                </div>
            </div>
            <div class="contImagen cols">
                <h5>Imagen Vehiculo</h5>
                <img v-if="editar && ruta !== undefined" :src="ruta" class="imagen img-fluid rounded-start">
                <img v-else-if="ruta === undefined" src="@/assets/logo.png" class="imagen img-fluid rounded-start">
                <img v-else :src="ruta" class="imagen img-fluid rounded-start">

            </div>
            <div class="container text-center">
                <button v-if="editar" class="btn btn-primary">Editar</button>
                <button v-else class="btn btn-primary " @click="GuardarImagenVehiculo">Crear</button>
            </div>
        </div>
    </div>
</template>

<script>
import utilidades from "@/services/Axios";
export default {
    name: 'VehiculoDetalle',
    watch: {
        $route: {
            handler: function (to) {
                if (to.params.id === "Crear" || to.params.id === undefined) {
                    this.editar = false;
                } else {
                    this.editar = true;
                    this.vehiculo.serialVehiculo = to.params.id;
                    this.CargarVehiculo(to.params.id);
                }
            },
            immediate: true,
        }
    },
    data() {
        return {
            vehiculo: {},
            editar: false,
            ruta: ""
        }
    },
    created() {
    },
    methods: {
        CargarImagen(event) {
            if (event.target.files && event.target.files[0]) {

                const lector = new FileReader();

                lector.onload = (e) => {
                    this.ruta = e.target.result;
                    const arrayBuffer = e.target.result;
                    const bytes = new Uint8Array(arrayBuffer);
                    this.vehiculo.rutaImagen = bytes;
                };
                lector.readAsDataURL(event.target.files[0]);
            }
        },
        CargarVehiculo(serialVehiculo) {
            console.log("entro");
            let serial = {
                serialVehiculo: serialVehiculo
            }
            utilidades.Get("Vehiculos/obtener-vehiculo", serial)
                .then((respuesta) => {
                    this.vehiculo = respuesta.data;
                })
                .catch((error) => {
                    console.log("error: " + error);
                })
        },
        GuardarImagenVehiculo(){
            if(this.ruta!== null && this.ruta !== undefined){
                const byteCharacters = atob(this.ruta.split(',')[1]);
const byteNumbers = new Array(byteCharacters.length);
for (let i = 0; i < byteCharacters.length; i++) {
  byteNumbers[i] = byteCharacters.charCodeAt(i);
}
const byteArray = new Uint8Array(byteNumbers);
                const formData = new FormData();
                formData.append('archivo', byteArray);
                formData.append('serialVehiculo', this.vehiculo.serialVehiculo);

                utilidades.PostArchivo("Vehiculos/cargar-imagen-vehiculo",formData)
                .then((respuesta)=>{
                    console.log("respuesta: "+ respuesta);
                }).catch((error)=>{
                    console.log("error:"+ error);
                })
            }
        },
        GuardarVehiculo() {
            let datos = {
                SerialVehiculo: this.vehiculo.serialVehiculo,
                Placa: this.vehiculo.placa,
                Marca: this.vehiculo.marca,
                Modelo: this.vehiculo.modelo,
                FechaCrea: new Date(),
                Activo: true,
                Costo: 0
            }           

            if (this.vehiculo != undefined) {
                utilidades.Post("Vehiculos/cargar-vehiculo", datos)
                    .then((respuesta) => {
                        console.log(respuesta.data);
                       // this.GuardarImagenVehiculo(this.ruta);
                    })
                    .catch((error) => {
                        console.log("error:" + error);
                    });
            }
        }
    },
}
</script>

<style>
.imagen {
    width: 350px;
    margin: auto;
}

.contImagen {
    border: 2px solid black;
    border-radius: 10px;
    height: auto;
}
</style>