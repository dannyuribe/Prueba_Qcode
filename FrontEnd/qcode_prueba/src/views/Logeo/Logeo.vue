<template>
  <div>
    <h1>Logeo</h1>
    <div>
      <label for="usuarioInput">Usuario: </label>
      <input 
        type="text" 
        id="usuarioInput"
        v-model="usuario.usuario" />
    </div>
    <div>
      <label for="contrasenaInput">Contraseña: </label>
      <input 
        type="text" 
        id="contrasenaInput" 
        v-model="usuario.contrasena"/>
    </div>
    <div>
      <button @click="Autenticar">Ingresar</button>
    </div>
  </div>
</template>

<script>
import UsaAxios from "@/services/Axios";
import { Console } from "console";
export default {
  name: "ViewLogeo",
  data() {
    return {
        usuario:{}
    };
  },
  methods: {
    Autenticar() {
      if (this.usuario) {
        UsaAxios.post("", usuario).then((respuesta) => {
          console.log(respuesta);
        });
      }
    },
  },
};
</script>

<style></style>
