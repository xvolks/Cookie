package com.ankamagames.dofus.network.types.game.character.characteristic
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class CharacterSpellModification implements INetworkType
   {
      
      public static const protocolId:uint = 215;
       
      
      public var modificationType:uint = 0;
      
      public var spellId:uint = 0;
      
      public var value:CharacterBaseCharacteristic;
      
      private var _valuetree:FuncTree;
      
      public function CharacterSpellModification()
      {
         this.value = new CharacterBaseCharacteristic();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 215;
      }
      
      public function initCharacterSpellModification(param1:uint = 0, param2:uint = 0, param3:CharacterBaseCharacteristic = null) : CharacterSpellModification
      {
         this.modificationType = param1;
         this.spellId = param2;
         this.value = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.modificationType = 0;
         this.spellId = 0;
         this.value = new CharacterBaseCharacteristic();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterSpellModification(param1);
      }
      
      public function serializeAs_CharacterSpellModification(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.modificationType);
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element spellId.");
         }
         param1.writeVarShort(this.spellId);
         this.value.serializeAs_CharacterBaseCharacteristic(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterSpellModification(param1);
      }
      
      public function deserializeAs_CharacterSpellModification(param1:ICustomDataInput) : void
      {
         this._modificationTypeFunc(param1);
         this._spellIdFunc(param1);
         this.value = new CharacterBaseCharacteristic();
         this.value.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterSpellModification(param1);
      }
      
      public function deserializeAsyncAs_CharacterSpellModification(param1:FuncTree) : void
      {
         param1.addChild(this._modificationTypeFunc);
         param1.addChild(this._spellIdFunc);
         this._valuetree = param1.addChild(this._valuetreeFunc);
      }
      
      private function _modificationTypeFunc(param1:ICustomDataInput) : void
      {
         this.modificationType = param1.readByte();
         if(this.modificationType < 0)
         {
            throw new Error("Forbidden value (" + this.modificationType + ") on element of CharacterSpellModification.modificationType.");
         }
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         this.spellId = param1.readVarUhShort();
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element of CharacterSpellModification.spellId.");
         }
      }
      
      private function _valuetreeFunc(param1:ICustomDataInput) : void
      {
         this.value = new CharacterBaseCharacteristic();
         this.value.deserializeAsync(this._valuetree);
      }
   }
}
