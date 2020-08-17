package com.ankamagames.dofus.network.types.game.dare
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class DareReward implements INetworkType
   {
      
      public static const protocolId:uint = 505;
       
      
      public var type:uint = 0;
      
      public var monsterId:uint = 0;
      
      public var kamas:Number = 0;
      
      public var dareId:Number = 0;
      
      public function DareReward()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 505;
      }
      
      public function initDareReward(param1:uint = 0, param2:uint = 0, param3:Number = 0, param4:Number = 0) : DareReward
      {
         this.type = param1;
         this.monsterId = param2;
         this.kamas = param3;
         this.dareId = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.type = 0;
         this.monsterId = 0;
         this.kamas = 0;
         this.dareId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_DareReward(param1);
      }
      
      public function serializeAs_DareReward(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.type);
         if(this.monsterId < 0)
         {
            throw new Error("Forbidden value (" + this.monsterId + ") on element monsterId.");
         }
         param1.writeVarShort(this.monsterId);
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element kamas.");
         }
         param1.writeVarLong(this.kamas);
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element dareId.");
         }
         param1.writeDouble(this.dareId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareReward(param1);
      }
      
      public function deserializeAs_DareReward(param1:ICustomDataInput) : void
      {
         this._typeFunc(param1);
         this._monsterIdFunc(param1);
         this._kamasFunc(param1);
         this._dareIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareReward(param1);
      }
      
      public function deserializeAsyncAs_DareReward(param1:FuncTree) : void
      {
         param1.addChild(this._typeFunc);
         param1.addChild(this._monsterIdFunc);
         param1.addChild(this._kamasFunc);
         param1.addChild(this._dareIdFunc);
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
         if(this.type < 0)
         {
            throw new Error("Forbidden value (" + this.type + ") on element of DareReward.type.");
         }
      }
      
      private function _monsterIdFunc(param1:ICustomDataInput) : void
      {
         this.monsterId = param1.readVarUhShort();
         if(this.monsterId < 0)
         {
            throw new Error("Forbidden value (" + this.monsterId + ") on element of DareReward.monsterId.");
         }
      }
      
      private function _kamasFunc(param1:ICustomDataInput) : void
      {
         this.kamas = param1.readVarUhLong();
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element of DareReward.kamas.");
         }
      }
      
      private function _dareIdFunc(param1:ICustomDataInput) : void
      {
         this.dareId = param1.readDouble();
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element of DareReward.dareId.");
         }
      }
   }
}
