package com.ankamagames.dofus.network.types.game.character
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class CharacterMinimalInformations extends CharacterBasicMinimalInformations implements INetworkType
   {
      
      public static const protocolId:uint = 110;
       
      
      public var level:uint = 0;
      
      public function CharacterMinimalInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 110;
      }
      
      public function initCharacterMinimalInformations(param1:Number = 0, param2:String = "", param3:uint = 0) : CharacterMinimalInformations
      {
         super.initCharacterBasicMinimalInformations(param1,param2);
         this.level = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.level = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterMinimalInformations(param1);
      }
      
      public function serializeAs_CharacterMinimalInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterBasicMinimalInformations(param1);
         if(this.level < 1 || this.level > 206)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterMinimalInformations(param1);
      }
      
      public function deserializeAs_CharacterMinimalInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._levelFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterMinimalInformations(param1);
      }
      
      public function deserializeAsyncAs_CharacterMinimalInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._levelFunc);
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 1 || this.level > 206)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of CharacterMinimalInformations.level.");
         }
      }
   }
}
