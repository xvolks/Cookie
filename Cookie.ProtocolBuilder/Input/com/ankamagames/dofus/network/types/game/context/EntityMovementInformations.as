package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class EntityMovementInformations implements INetworkType
   {
      
      public static const protocolId:uint = 63;
       
      
      public var id:int = 0;
      
      public var steps:Vector.<int>;
      
      private var _stepstree:FuncTree;
      
      public function EntityMovementInformations()
      {
         this.steps = new Vector.<int>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 63;
      }
      
      public function initEntityMovementInformations(param1:int = 0, param2:Vector.<int> = null) : EntityMovementInformations
      {
         this.id = param1;
         this.steps = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
         this.steps = new Vector.<int>();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_EntityMovementInformations(param1);
      }
      
      public function serializeAs_EntityMovementInformations(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.id);
         param1.writeShort(this.steps.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.steps.length)
         {
            param1.writeByte(this.steps[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EntityMovementInformations(param1);
      }
      
      public function deserializeAs_EntityMovementInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         this._idFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readByte();
            this.steps.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EntityMovementInformations(param1);
      }
      
      public function deserializeAsyncAs_EntityMovementInformations(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         this._stepstree = param1.addChild(this._stepstreeFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readInt();
      }
      
      private function _stepstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._stepstree.addChild(this._stepsFunc);
            _loc3_++;
         }
      }
      
      private function _stepsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readByte();
         this.steps.push(_loc2_);
      }
   }
}
