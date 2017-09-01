package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightResultPlayerListEntry extends FightResultFighterListEntry implements INetworkType
   {
      
      public static const protocolId:uint = 24;
       
      
      public var level:uint = 0;
      
      public var additional:Vector.<FightResultAdditionalData>;
      
      private var _additionaltree:FuncTree;
      
      public function FightResultPlayerListEntry()
      {
         this.additional = new Vector.<FightResultAdditionalData>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 24;
      }
      
      public function initFightResultPlayerListEntry(param1:uint = 0, param2:uint = 0, param3:FightLoot = null, param4:Number = 0, param5:Boolean = false, param6:uint = 0, param7:Vector.<FightResultAdditionalData> = null) : FightResultPlayerListEntry
      {
         super.initFightResultFighterListEntry(param1,param2,param3,param4,param5);
         this.level = param6;
         this.additional = param7;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.level = 0;
         this.additional = new Vector.<FightResultAdditionalData>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightResultPlayerListEntry(param1);
      }
      
      public function serializeAs_FightResultPlayerListEntry(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightResultFighterListEntry(param1);
         if(this.level < 1 || this.level > 206)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
         param1.writeShort(this.additional.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.additional.length)
         {
            param1.writeShort((this.additional[_loc2_] as FightResultAdditionalData).getTypeId());
            (this.additional[_loc2_] as FightResultAdditionalData).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightResultPlayerListEntry(param1);
      }
      
      public function deserializeAs_FightResultPlayerListEntry(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:FightResultAdditionalData = null;
         super.deserialize(param1);
         this._levelFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(FightResultAdditionalData,_loc4_);
            _loc5_.deserialize(param1);
            this.additional.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightResultPlayerListEntry(param1);
      }
      
      public function deserializeAsyncAs_FightResultPlayerListEntry(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._levelFunc);
         this._additionaltree = param1.addChild(this._additionaltreeFunc);
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 1 || this.level > 206)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of FightResultPlayerListEntry.level.");
         }
      }
      
      private function _additionaltreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._additionaltree.addChild(this._additionalFunc);
            _loc3_++;
         }
      }
      
      private function _additionalFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:FightResultAdditionalData = ProtocolTypeManager.getInstance(FightResultAdditionalData,_loc2_);
         _loc3_.deserialize(param1);
         this.additional.push(_loc3_);
      }
   }
}
