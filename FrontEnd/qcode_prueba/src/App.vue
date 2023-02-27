<template>
  <div class="container text-center">
      <MenuComponent :login="logeado"></MenuComponent>
      <hr/>
      <router-view @logeo-inicio="valida"></router-view>
  </div>
</template>

<script>
import MenuComponent from "@/components/Menu.Component.vue";
export default {
  name: "App",
  components: {
    MenuComponent,
  },
  data() {
    return {
      logeado:false
    }
  },
  created() {
    console.log("logeado: "+ this.logeado);
  },
  methods: {
    valida(valor){
      console.log("Este-valor:"+valor);
      this.logeado=valor;
    }
  },
};
</script>