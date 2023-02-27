<template>
    <div class="cont">
        <h1>Vehiculos</h1>
        <div class="btn-toolbar justify-content-between">
            <router-link 
                class="btn btn-primary" 
                :to="{ 
                    name: 'VehiculoDetalle',
                    params: { id: 'Crear'}}">
                Crear vehiculo
            </router-link>
        </div>
        <div class="contTabla">
            <table class="table">
                <thead>
                    <tr>
                        <th>Serial vehiculo</th>
                        <th>Placa</th>
                        <th>Costo Ingreso</th>
                        <th>Fecha Creación</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="vehiculo in vehiculos" :key="vehiculo">
                        <td>
                            <router-link :to="{
                                name: 'VehiculoDetalle',
                                params: { id: vehiculo.serialVehiculo }
                            }">
                                {{ vehiculo.serialVehiculo }}
                            </router-link>
                        </td>
                        <td>{{ vehiculo.placa }}</td>
                        <td>{{ vehiculo.costo }}</td>
                        <td>{{ FiltroFecha(vehiculo.fechaCrea) }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import utilidades from "@/services/Axios";
export default {
    name: "VehiculoPrincipal",
    data() {
        return {
            vehiculos: [],
            serialVehiculo: ""
        }
    },
    created() {
        this.CargarVehiculos();
    },
    methods: {
        CargarVehiculos() {
            utilidades.Get("Vehiculos/obtener-vehiculos", {})
                .then((respuesta) => {
                    this.vehiculos = respuesta.data;
                })
                .catch((error) => {
                    console.log("error:" + error);
                });
        },
        FiltroFecha(datoFecha) {
            var date = new Date(datoFecha);
            var fechaFiltrada =
                date.getDate() +
                "/" +
                (date.getMonth() + 1) +
                "/" +
                date.getFullYear();
            return fechaFiltrada;
        },
    },
};
</script>

