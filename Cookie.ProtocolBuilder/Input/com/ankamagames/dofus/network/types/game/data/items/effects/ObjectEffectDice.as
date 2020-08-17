package com.ankamagames.dofus.network.types.game.data.items.effects
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectEffectDice extends ObjectEffect implements INetworkType
   {
      
      public static const protocolId:uint = 73;
       
      
      public var diceNum:uint = 0;
      
      public var diceSide:uint = 0;
      
      public var diceConst:uint = 0;
      
      public function ObjectEffectDice()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 73;
      }
      
      public function initObjectEffectDice(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0) : ObjectEffectDice
      {
         super.initObjectEffect(param1);
         this.diceNum = param2;
         this.diceSide = param3;
         this.diceConst = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.diceNum = 0;
         this.diceSide = 0;
         this.diceConst = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectEffectDice(param1);
      }
      
      public function serializeAs_ObjectEffectDice(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectEffect(param1);
         if(this.diceNum < 0)
         {
            throw new Error("Forbidden value (" + this.diceNum + ") on element diceNum.");
         }
         param1.writeVarShort(this.diceNum);
         if(this.diceSide < 0)
         {
            throw new Error("Forbidden value (" + this.diceSide + ") on element diceSide.");
         }
         param1.writeVarShort(this.diceSide);
         if(this.diceConst < 0)
         {
            throw new Error("Forbidden value (" + this.diceConst + ") on element diceConst.");
         }
         param1.writeVarShort(this.diceConst);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectEffectDice(param1);
      }
      
      public function deserializeAs_ObjectEffectDice(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._diceNumFunc(param1);
         this._diceSideFunc(param1);
         this._diceConstFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectEffectDice(param1);
      }
      
      public function deserializeAsyncAs_ObjectEffectDice(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._diceNumFunc);
         param1.addChild(this._diceSideFunc);
         param1.addChild(this._diceConstFunc);
      }
      
      private function _diceNumFunc(param1:ICustomDataInput) : void
      {
         this.diceNum = param1.readVarUhShort();
         if(this.diceNum < 0)
         {
            throw new Error("Forbidden value (" + this.diceNum + ") on element of ObjectEffectDice.diceNum.");
         }
      }
      
      private function _diceSideFunc(param1:ICustomDataInput) : void
      {
         this.diceSide = param1.readVarUhShort();
         if(this.diceSide < 0)
         {
            throw new Error("Forbidden value (" + this.diceSide + ") on element of ObjectEffectDice.diceSide.");
         }
      }
      
      private function _diceConstFunc(param1:ICustomDataInput) : void
      {
         this.diceConst = param1.readVarUhShort();
         if(this.diceConst < 0)
         {
            throw new Error("Forbidden value (" + this.diceConst + ") on element of ObjectEffectDice.diceConst.");
         }
      }
   }
}
