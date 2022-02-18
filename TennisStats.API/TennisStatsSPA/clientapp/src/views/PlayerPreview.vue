<template>
	<div id="player-preview">
		<navbar />

		<div id="player-container">
			<div id="player-poster">
				<img :src="player.picture" alt="Player picture" />
			</div>

			<div id="player-info">
				<div>
					<h1>{{ player.firstname }} {{ player.lastname }}</h1>
					<h3>{{ player.shortname }}</h3>
					<h3>{{ player.data.age }} Years Old</h3>
					<h3>{{ player.sex }}</h3>
					<h3>
						<span id="plyer-rank"
							  :style="{ 'background-color': getRankColor() }">{{ player.data.rank }}</span>
					</h3>

					<h3>Points: {{ player.data.points }}</h3>
					<h3>Country : {{ player.country.code }}</h3>
					<h3>
						Last:
						<span v-for="(x, index) in player.data.last"
							  :key="index">{{ x }}</span>
					</h3>
				</div>
				<div id="options">
					<button @click="showModal = true" class="edit">Edit</button>
					<button @click="deletePlayer" class="delete">Delete</button>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import NavBar from "@/components/NavBar.vue";
	export default {
		components: {
			NavBar,
		},
		props: {
			id: {
				type: Number,
				default: null,
			},
		},
		data() {
			return {
			
				player: {},
			};
		},
		methods: {
              getRankColor() {
      if (this.player.data.rank < 5) return "#5eb85e";
      if (this.player.data.rank > 5) return "#ffa809";
      return "#e10505";
    },
		},
		created() {
			const player = this.$store.getters.getPlayerById(parseInt(this.id));
			if (player) {
				this.player = player;
			}
		},
	};
</script>

<style lang='scss' scoped>
	#player-preview {
		display: flex;
		overflow: auto;

		#player-container {
			display: flex;
			justify-content: center;
			flex-grow: 1;
			margin-top: 90px;
			padding: 0 1rem;

			#player-poster {
				flex-grow: 1;
				min-width: 400px;

				img {
					max-width: 300px;
					box-shadow: 0 14px 28px rgba(0, 0, 0, 0.473),
						0 10px 10px rgba(0, 0, 0, 0.473);
					margin-bottom: 7px;
					border-radius: 15px;
				}
			}

			#player-info {
				display: flex;
				flex-grow: 2;
				text-align: left;
				flex-direction: column;
				justify-content: space-between;

				h1 {
					color: white;
					margin-bottom: 2rem;
				}

				h3 {
					color: rgb(143, 143, 143);

					#player-rank {
						display: flex;
						justify-content: center;
						border-radius: 10px;
						font-size: 20px;
						width: 53px;
						color: white;
					}

					span {
						margin-right: 5px;
					}
				}

				#options {
					max-width: 180px;
					display: flex;
					justify-content: space-between;
					margin-top: 1rem;

					.edit {
						height: 30px;
						width: 80px;
						background-color: #5eb85e;
						border: none;
						text-transform: uppercase;
						font-weight: 600;
						border-radius: 10px;
						outline: none;
						cursor: pointer;
					}

					.delete {
						height: 30px;
						width: 80px;
						background-color: #e10505;
						border: none;
						text-transform: uppercase;
						font-weight: 600;
						border-radius: 10px;
						outline: none;
						cursor: pointer;
					}
				}
			}
		}

		#player-form {
			display: flex;
			flex-direction: column;
			text-align: left;

			& > div {
				display: flex;
				flex-direction: column;

				#player-input {
					display: flex;
					justify-content: space-between;
				}
			}

			.add-player {
				background-color: green;
				text-align: center;
				color: white;
				margin-left: 5px;
				height: 100%;
				padding: 2px 10px;
				font-size: 20px;
				padding: 1re;
				align-self: center;
				cursor: pointer;
			}
		}

		#update-player {
			background-color: #5eb85e;
			border: none;
			padding: 5px;
			width: 70px;
			color: white;
			border-radius: 10px;
			cursor: pointer;
			text-transform: uppercase;
			outline: none;
		}
	}
</style>