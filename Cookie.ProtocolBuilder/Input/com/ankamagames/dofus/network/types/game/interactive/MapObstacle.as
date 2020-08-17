package com.ankamagames.dofus.network.types.game.interactive
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class MapObstacle implements INetworkType
   {
      
      public static const protocolId:uint = 200;
       
      
      public var obstacleCellId:uint = 0;
      
      public var state:uint = 0;
      
      public function MapObstacle()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 200;
      }
      
      public function initMapObstacle(param1:uint = 0, param2:uint = 0) : MapObstacle
      {
         this.obstacleCellId = param1;
         this.state = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.obstacleCellId = 0;
         this.state = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MapObstacle(param1);
      }
      
      public function serializeAs_MapObstacle(param1:ICustomDataOutput) : void
      {
         if(this.obstacleCellId < 0 || this.obstacleCellId > 559)
         {
            throw new Error("Forbidden value (" + this.obstacleCellId + ") on element obstacleCellId.");
         }
         param1.writeVarShort(this.obstacleCellId);
         param1.writeByte(this.state);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapObstacle(param1);
      }
      
      public function deserializeAs_MapObstacle(param1:ICustomDataInput) : void
      {
         this._obstacleCellIdFunc(param1);
         this._stateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapObstacle(param1);
      }
      
      public function deserializeAsyncAs_MapObstacle(param1:FuncTree) : void
      {
         param1.addChild(this._obstacleCellIdFunc);
         param1.addChild(this._stateFunc);
      }
      
      private function _obstacleCellIdFunc(param1:ICustomDataInput) : void
      {
         this.obstacleCellId = param1.readVarUhShort();
         if(this.obstacleCellId < 0 || this.obstacleCellId > 559)
         {
            throw new Error("Forbidden value (" + this.obstacleCellId + ") on element of MapObstacle.obstacleCellId.");
         }
      }
      
      private function _stateFunc(param1:ICustomDataInput) : void
      {
         this.state = param1.readByte();
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element of MapObstacle.state.");
         }
      }
   }
}
