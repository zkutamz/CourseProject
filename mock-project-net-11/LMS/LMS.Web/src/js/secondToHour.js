/**
 * Convert a second as string to a string contains hours, minutes, and seconds;
 */
const SecondToHour = (value) => {
    const second = parseInt(value, 10);

    let hours = Math.floor(second / 3600);
    let minutes = Math.floor((second - (hours * 3600)) / 60);
    let seconds = second - (hours * 3600) - (minutes * 60);

    if (hours < 10) hours = '0' + hours;
    if (minutes < 10) minutes = '0' + minutes;
    if (seconds < 10) seconds = '0' + seconds;

    return hours + ':' + minutes + ':' + seconds;
}

export default SecondToHour;