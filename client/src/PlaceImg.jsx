import capa from './images/capa.jpg';

export default function PlaceImg(className=null) {


    if(!className){
        className = 'object-cover';
    }


  return (
    <div>
        <img className="className" src={capa} />
    </div>
  );
}