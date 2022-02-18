<template>
  <div id="filters">
    <h3>Filters</h3>
	<p v-for="(filter,index) in filters" :key ="index" @click="applyFilter(filter)">
		{{filter.name}}
	</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      filters: [
        {
          name: "Rank highest",
          key: "rank",
          order: "desc",
        },
        {
          name: "Rank lowest",
          key: "rank",
          order: "asc",
        },
        {
          name: "Points highest",
          key: "points",
          order: "desc",
        },
        {
          name: "Points lowest",
          key: "points",
          order: "asc",
        },
      ],
    };
  },
  methods:{
	  applyFilter(filter){
		  this.$store.dispatch("filter",filter);
	  }
  }
};
</script>

<style lang='scss' scoped>
#filters {
  text-align: left;
  color: rgb(143, 143, 143);
  cursor: pointer;

  p {
    margin-left: 10px;
  }
}
</style>