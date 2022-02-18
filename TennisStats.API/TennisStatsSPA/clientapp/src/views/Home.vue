<template>
  <div class="home">
    <nav-bar />
    <div id="main-section">
     <side-bar />
     <player-list />
    </div>
  </div>
</template>

<script>
import NavBar from '../components/NavBar.vue';
import SideBar from '../components/SideBar.vue';
import PlayerList from '../components/PlayerList.vue';
export default {
  name: 'Home',
  components: {
   NavBar,
   SideBar,
   PlayerList,
  }
}
</script>
<style lang="scss" scoped>
	.home {
		display: flex;
		flex-direction: column;

		#main-section {
			display: flex;
			margin-top: 50px;
		}
	}
</style>