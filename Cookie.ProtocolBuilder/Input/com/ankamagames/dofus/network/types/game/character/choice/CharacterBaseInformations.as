package com.ankamagames.dofus.network.types.game.character.choice
{
   import com.ankamagames.dofus.network.types.game.character.CharacterMinimalPlusLookInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class CharacterBaseInformations extends CharacterMinimalPlusLookInformations implements INetworkType
   {
      
      public static const protocolId:uint = 45;
       
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public function CharacterBaseInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 45;
      }
      
      public function initCharacterBaseInformations(param1:Number = 0, param2:String = "", param3:uint = 0, param4:EntityLook = null, param5:int = 0, param6:Boolean = false) : CharacterBaseInformations
      {
         super.initCharacterMinimalPlusLookInformations(param1,param2,param3,param4);
         this.breed = param5;
         this.sex = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.breed = 0;
         this.sex = false;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterBaseInformations(param1);
      }
      
      public function serializeAs_CharacterBaseInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterMinimalPlusLookInformations(param1);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterBaseInformations(param1);
      }
      
      public function deserializeAs_CharacterBaseInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterBaseInformations(param1);
      }
      
      public function deserializeAsyncAs_CharacterBaseInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
   }
}
