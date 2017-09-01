package com.ankamagames.dofus.network.types.game.character.choice
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class CharacterToRecolorInformation extends AbstractCharacterToRefurbishInformation implements INetworkType
   {
      
      public static const protocolId:uint = 212;
       
      
      public function CharacterToRecolorInformation()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 212;
      }
      
      public function initCharacterToRecolorInformation(param1:Number = 0, param2:Vector.<int> = null, param3:uint = 0) : CharacterToRecolorInformation
      {
         super.initAbstractCharacterToRefurbishInformation(param1,param2,param3);
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterToRecolorInformation(param1);
      }
      
      public function serializeAs_CharacterToRecolorInformation(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractCharacterToRefurbishInformation(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterToRecolorInformation(param1);
      }
      
      public function deserializeAs_CharacterToRecolorInformation(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterToRecolorInformation(param1);
      }
      
      public function deserializeAsyncAs_CharacterToRecolorInformation(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
      }
   }
}
