package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ActorOrientation implements INetworkType
   {
      
      public static const protocolId:uint = 353;
       
      
      public var id:Number = 0;
      
      public var direction:uint = 1;
      
      public function ActorOrientation()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 353;
      }
      
      public function initActorOrientation(param1:Number = 0, param2:uint = 1) : ActorOrientation
      {
         this.id = param1;
         this.direction = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
         this.direction = 1;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ActorOrientation(param1);
      }
      
      public function serializeAs_ActorOrientation(param1:ICustomDataOutput) : void
      {
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeDouble(this.id);
         param1.writeByte(this.direction);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ActorOrientation(param1);
      }
      
      public function deserializeAs_ActorOrientation(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this._directionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ActorOrientation(param1);
      }
      
      public function deserializeAsyncAs_ActorOrientation(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         param1.addChild(this._directionFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readDouble();
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of ActorOrientation.id.");
         }
      }
      
      private function _directionFunc(param1:ICustomDataInput) : void
      {
         this.direction = param1.readByte();
         if(this.direction < 0)
         {
            throw new Error("Forbidden value (" + this.direction + ") on element of ActorOrientation.direction.");
         }
      }
   }
}
