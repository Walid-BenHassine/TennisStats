<template>
  <div class="player">
    <img :src="player.picture" alt="player picture" @click="openDetails" />
    <div class="description">
      <div class="basic-info">
          <h3>{{ player.shortname }}</h3>
          <span :style="{ 'background-color': getRankColor() }">
              {{
          player.data.rank
              }}
          </span>
      </div>
      <p>{{ player.sex }}</p>
      <p>{{ player.country.code }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
        player: {
      type: Object,
      default: () => {},
    },
  },
  methods: {
      getRankColor() {
          if (this.player.data.rank < 5) return "#5eb85e";
          if (this.player.data.rank > 5) return "#ffa809";
      return "#e10505";
    },
    openDetails() {
      this.$router.push({
        name: "playerPreview",
        params: { id: this.player.id },
      });
    },
  },
};
</script>

<style lang='scss' scoped>
.player {
  flex: 1;
  margin: 1rem;
  min-width: 300px;
  max-width: 300px;
  position: relative;

  img {
    max-width: 100%;
    box-shadow: 0 14px 28px rgba(0, 0, 0, 0.473),
      0 10px 10px rgba(0, 0, 0, 0.473);
    margin-bottom: 7px;
    border-radius: 15px;
    cursor: pointer;
  }

  .description {
    padding: 1rem 0;

    .basic-info {
      display: flex;
      justify-content: space-between;

      h3 {
        margin: 0;
        text-align: left;
        color: white;
      }

      span {
        border-radius: 10px;
        font-size: 20px;
        width: 53px;
        color: white;
      }
    }

    p {
      margin: 5px 0;
      color: rgb(143, 143, 143);
      text-align: left;
    }
  }
}
</style>