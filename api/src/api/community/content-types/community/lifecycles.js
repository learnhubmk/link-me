module.exports = {
  async beforeCreate(event) {
    const {data} = event.params;
    data.submitted_at = new Date();
  }
}
