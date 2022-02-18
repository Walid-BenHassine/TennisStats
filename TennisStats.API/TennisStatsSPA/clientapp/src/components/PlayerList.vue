<template>
  <div id="player-container">
<movie v-for="player in players" :key="player.id" :player="player"/>
  </div>
</template>
<script>
import Player from "./Player.vue";
export default {
  components: {
    Player,
  },
  data() {
    return {
      //players : []
    };
  },
  computed: {
    players() {
      return this.$store.getters.getPlayers;
    },
  },
};
</script>
<style lang='scss' scoped>
#movie-container {
  padding-top: 1rem;
  display: flex;
  flex-wrap: wrap;
  flex-grow: 2;
  justify-content: center;
}
</style>