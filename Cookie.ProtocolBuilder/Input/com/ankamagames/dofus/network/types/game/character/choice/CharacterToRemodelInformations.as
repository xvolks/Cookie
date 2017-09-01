package com.ankamagames.dofus.network.types.game.character.choice
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class CharacterToRemodelInformations extends CharacterRemodelingInformation implements INetworkType
   {
      
      public static const protocolId:uint = 477;
       
      
      public var possibleChangeMask:uint = 0;
      
      public var mandatoryChangeMask:uint = 0;
      
      public function CharacterToRemodelInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 477;
      }
      
      public function initCharacterToRemodelInformations(param1:Number = 0, param2:String = "", param3:int = 0, param4:Boolean = false, param5:uint = 0, param6:Vector.<int> = null, param7:uint = 0, param8:uint = 0) : CharacterToRemodelInformations
      {
         super.initCharacterRemodelingInformation(param1,param2,param3,param4,param5,param6);
         this.possibleChangeMask = param7;
         this.mandatoryChangeMask = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.possibleChangeMask = 0;
         this.mandatoryChangeMask = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterToRemodelInformations(param1);
      }
      
      public function serializeAs_CharacterToRemodelInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterRemodelingInformation(param1);
         if(this.possibleChangeMask < 0)
         {
            throw new Error("Forbidden value (" + this.possibleChangeMask + ") on element possibleChangeMask.");
         }
         param1.writeByte(this.possibleChangeMask);
         if(this.mandatoryChangeMask < 0)
         {
            throw new Error("Forbidden value (" + this.mandatoryChangeMask + ") on element mandatoryChangeMask.");
         }
         param1.writeByte(this.mandatoryChangeMask);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterToRemodelInformations(param1);
      }
      
      public function deserializeAs_CharacterToRemodelInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._possibleChangeMaskFunc(param1);
         this._mandatoryChangeMaskFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterToRemodelInformations(param1);
      }
      
      public function deserializeAsyncAs_CharacterToRemodelInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._possibleChangeMaskFunc);
         param1.addChild(this._mandatoryChangeMaskFunc);
      }
      
      private function _possibleChangeMaskFunc(param1:ICustomDataInput) : void
      {
         this.possibleChangeMask = param1.readByte();
         if(this.possibleChangeMask < 0)
         {
            throw new Error("Forbidden value (" + this.possibleChangeMask + ") on element of CharacterToRemodelInformations.possibleChangeMask.");
         }
      }
      
      private function _mandatoryChangeMaskFunc(param1:ICustomDataInput) : void
      {
         this.mandatoryChangeMask = param1.readByte();
         if(this.mandatoryChangeMask < 0)
         {
            throw new Error("Forbidden value (" + this.mandatoryChangeMask + ") on element of CharacterToRemodelInformations.mandatoryChangeMask.");
         }
      }
   }
}
